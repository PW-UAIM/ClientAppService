using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZsutPw.Patterns.Application.Model;

namespace majumi.CarService.ClientsAppService.Rest.Model.Model;

public class Model
{
    public int ClientID { get; set; }

    public CarData[] LoadCarList()
    {
        FakeNetworkClient client = new();
        return client.GetCarsByClientID(ClientID);
    }
}
