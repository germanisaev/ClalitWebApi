namespace GetPatientInfo;

public interface ICorrelationIdGenerators
{
    string Get();
    void Set(string correlationId);
}
