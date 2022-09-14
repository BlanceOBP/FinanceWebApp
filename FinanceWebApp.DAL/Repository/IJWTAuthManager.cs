using FinanceWebApp.Domain;
using FinanceWebApp.Domain.Response;
using Dapper;


namespace FinanceWebApp.DAL.Repository
{
    public interface IJWTAuthManager
    {
        BaseResponse<string> GenerateJWT(Users user); //Создание Веб Токенна
        BaseResponse<T> Execute_Command<T>(string query, DynamicParameters sp_params);
        BaseResponse<List<T>> getUserList<T>();
    }
}
