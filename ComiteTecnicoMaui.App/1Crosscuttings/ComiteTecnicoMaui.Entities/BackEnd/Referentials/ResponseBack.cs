using Newtonsoft.Json.Linq;

namespace ComiteTecnicoMaui.App._1Crosscuttings.ComiteTecnicoMaui.Entities.ComiteTecnicoMaui.Entities.BackEnd.Referentials;

public class ResponseBack<T> where T : class, new()
{
    public bool TransactionComplete { get; set; }

    public int ResponseCode { get; set; }

    public IList<string> Message { get; set; }

    public IList<T> Data { get; set; }

    public JArray MyJArray { get; set; }
}
