namespace Algo.model;

public class Operation
{
    public int? Id { get; set; }
    public string? Code { get; set; }
    public string? Label { get; set; }
    public int? Delay { get; set; }
    public int? InstallationDelay { get; set; }

    public Operation(int? id, string? code, string? label, int? delay, int? installationDelay)
    {
        Id = id;
        Code = code;
        Label = label;
        Delay = delay;
        InstallationDelay = installationDelay;
    }
    
}