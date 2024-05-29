using GetPatientInfo.Models;

namespace GetPatientInfo.Repository;

public class ResponseService: IResponseService
{
    private readonly DbContextClass _dbContext;

    public ResponseService(DbContextClass dbContext)
    {
         _dbContext = dbContext;
    }

    public async Task<ServiceResponse> GetPatientById(MyApiRequestParameters parameters)
    {
        var result = await Task.Run(() => _dbContext.Patients.FirstOrDefault(x => x.PatientId == parameters.PatientId));
        ServiceResponse response = new ServiceResponse();

        if(result == null) {
            response.StatusCode = 1;
            response.StatusDescription = "Patient Not Found";
            response.Patient = result;
        } else {
            response.StatusCode = 0;
            response.StatusDescription = "Success";
            response.Patient = result;
        }

        return response;
    }
}
