namespace GetPatientInfo;

public class CorrelationIdGenerators: ICorrelationIdGenerators
{
    private string _correlationId = Guid.NewGuid().ToString();

    public string Get() => _correlationId;

    public void Set(string correlationId) => _correlationId = correlationId;
}
