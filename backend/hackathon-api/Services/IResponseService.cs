using Microsoft.AspNetCore.Mvc;

namespace hackathon_api.Services
{
    public interface IResponseService
    {
        public Task<IActionResult> Response(int code, object returnobj);
    }
}
