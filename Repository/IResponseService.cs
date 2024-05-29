using GetPatientInfo.Models;

namespace GetPatientInfo.Repository;

public interface IResponseService
{
    Task<ServiceResponse> GetPatientById(MyApiRequestParameters parameters);
}
