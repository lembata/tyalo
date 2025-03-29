namespace Tyalo.Services;

public record TableRequest(int Skip, int Take, string? OrderBy);