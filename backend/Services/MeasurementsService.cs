using Microsoft.EntityFrameworkCore;
using Tyalo.Database;
using Tyalo.Database.Entities;

namespace Tyalo.Services;

public class MeasurementsService(TyaloDbContext db)
{
	public record Measurements
	{
		public double Weight { get; set; }
		public double? Neck { get; set; }
		public double? Chest { get; set; }
		public double? NaturalWaist { get; set; }
		public double? Waist { get; set; }
		public double? Thigh { get; set; }
		public double? Arm { get; set; }
		public double? BodyFatPercentage { get; set; }
		public DateTime Date { get; set; }
		public LengthUnit LengthUnit { get; set; }
		public WeightUnit WeightUnit { get; set; }
	}

	public async Task<string?> AddOrUpdateMeasurements(long userId, Measurements measurements)
	{
		if (measurements.Weight <= 0)
		{
			return "Invalid weight";
		}

		var entry = await db.MeasurementsEntries
			.Where(e => e.UserId == userId && e.Date.Date == measurements.Date.ToUniversalTime().Date)
			.FirstOrDefaultAsync();

		if (entry is null)
		{
			db.MeasurementsEntries.Add(new MeasurementsEntry()
			{
				UserId = userId,
				Weight = measurements.Weight,
				Neck = measurements.Neck,
				Chest = measurements.Chest,
				NaturalWaist = measurements.NaturalWaist,
				Waist = measurements.Waist,
				Thigh = measurements.Thigh,
				Arm = measurements.Arm,
				BodyFatPercentage = measurements.BodyFatPercentage,
				Date = measurements.Date.ToUniversalTime().Date,
				LengthUnit = measurements.LengthUnit,
				WeightUnit = measurements.WeightUnit,
				DateCreated = DateTime.UtcNow,
				DateModified = DateTime.UtcNow,
			});
		}
		else
		{
			entry.Weight = measurements.Weight;
			entry.Neck = measurements.Neck;
			entry.Chest = measurements.Chest;
			entry.NaturalWaist = measurements.NaturalWaist;
			entry.Waist = measurements.Waist;
			entry.Thigh = measurements.Thigh;
			entry.Arm = measurements.Arm;
			entry.BodyFatPercentage = measurements.BodyFatPercentage;
			entry.LengthUnit = measurements.LengthUnit;
			entry.WeightUnit = measurements.WeightUnit;
			entry.DateModified = DateTime.UtcNow;
		}

		await db.SaveChangesAsync();

		return null;
	}

	public record MeasurementsQuery
	{
		public DateTime? From { get; set; }
		public DateTime? To { get; set; }
		public int? Skip { get; set; }
		public int? Take { get; set; }
	}

	public async Task<IEnumerable<MeasurementsEntry>> GetMeasurements(long userId,  MeasurementsQuery q)
	{
		var query = db.MeasurementsEntries
			.Where(e => e.UserId == userId);

		if (q.From.HasValue)
		{
			query = query.Where(e => e.Date >= q.From.Value);
		}

		if (q.To.HasValue)
		{
			query = query.Where(e => e.Date <= q.To.Value);
		}

		if (q.Skip.HasValue)
		{
			query = query.Skip(q.Skip.Value);
		}

		if (q.Take.HasValue)
		{
			query = query.Take(q.Take.Value);
		}

		return await query.ToListAsync();
	}
}