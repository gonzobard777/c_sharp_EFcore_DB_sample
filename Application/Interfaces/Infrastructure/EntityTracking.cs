namespace Application.Interfaces.Infrastructure;

public enum EntityTracking
{
    Enabled,
    Disabled, // .AsNoTracking()
    DisabledWithIdentityResolution, // .AsNoTrackingWithIdentityResolution()
}