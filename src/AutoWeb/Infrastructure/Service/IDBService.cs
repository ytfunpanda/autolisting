
namespace AutoWeb.Infrastructure.Service {
    public interface IDBService {
        T GetData<T>(string identifier);
        T GetData<T>(string identifier, string lang);
    }
}