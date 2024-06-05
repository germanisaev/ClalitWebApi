using GetPatientInfo.Models;
using GetPatientInfo.Repository;

namespace GetPatientInfo.Test;

public class Tests
{
    Patient patient;
    ResponseService response1;// = new ServiceResponse();

    [SetUp]
    public void Setup()
    {
        // create new object patient
        patient = new Patient();
        ServiceResponse response = new ServiceResponse();
        //response1 = response;
    }

    [Test]
    public void Test1()
    {
        // test result search patient
        var parameters = new MyApiRequestParameters() { PatientId = 1 };
        //parameters.PatientId = 1;
        var result = response1.GetPatientById(parameters);
        //var count = books.GetBooks().Result.Count();

        //Assert.That(3 == count);
        Assert.That(result, Is.Not.Null);
        //Assert.Pass();
    }
}
