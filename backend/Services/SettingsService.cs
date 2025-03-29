using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tyalo.Database;
using Tyalo.Database.Entities;

namespace Tyalo.Services;

public class SettingsService(TyaloDbContext db)
{
	public record UserSettingsDto
	{
		[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
		public User? User { get; set; }

		public double Height { get; set; }
		public double StartingWeight { get; set; }
		public double GoalWeight { get; set; }
		public double GoalPercentage { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
		public LengthUnit LengthUnit { get; set; }
		public WeightUnit WeightUnit { get; set; }

		public static UserSettingsDto FromEntity(UserSettings entity)
		{
			return new UserSettingsDto
			{
				User = entity.User,
				Height = entity.Height,
				StartingWeight = entity.StartingWeight,
				GoalWeight = entity.GoalWeight,
				CreatedAt = entity.CreatedAt,
				ModifiedAt = entity.ModifiedAt,
				LengthUnit = entity.LengthUnit,
				WeightUnit = entity.WeightUnit
			};
		}

		public static UserSettings ToEntity(UserSettingsDto dto)
		{
			return new UserSettings
			{
				User = dto.User,
				Height = dto.Height,
				StartingWeight = dto.StartingWeight,
				GoalWeight = dto.GoalWeight,
				CreatedAt = dto.CreatedAt,
				ModifiedAt = dto.ModifiedAt,
				LengthUnit = dto.LengthUnit,
				WeightUnit = dto.WeightUnit
			};
		}

		public void UpdateEntity(UserSettings entity)
		{
			entity.Height = Height;
			entity.StartingWeight = StartingWeight;
			entity.GoalWeight = GoalWeight;
			entity.ModifiedAt = DateTime.UtcNow;
			entity.LengthUnit = LengthUnit;
			entity.WeightUnit = WeightUnit;
		}
	}


	public async Task<UserSettingsDto?> GetSettings(long userId)
	{

		var value = await db.UserSettings
			.FirstOrDefaultAsync(s => s.UserId == userId);

		if (value is not null)
		{
			 return UserSettingsDto.FromEntity(value);
		}

		return null;
	}

	public async Task<UserSettingsDto> UpdateSettings(long userId, UserSettingsDto dto)
	{
		var value = await db.UserSettings
			.FirstOrDefaultAsync(s => s.UserId == userId);

		if (value is null)
		{
			var user = new User() { Id = userId };

			db.Users.Attach(user);
			value = UserSettingsDto.ToEntity(dto);
			value.CreatedAt = DateTime.UtcNow;
			value.ModifiedAt = DateTime.UtcNow;
			value.User = user;
			db.UserSettings.Add(value);
		}
		else
		{
			dto.UpdateEntity(value);
		}

		await db.SaveChangesAsync();
		return UserSettingsDto.FromEntity(value);
	}
}