using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Infrastructure.Zalo.Interfaces;
public interface IZaloClient
{
    public Task<string> GetAccessToken(string code, string redirectUri);
    public Task<string> GetUserInfo(string accessToken);
    public Task<Unit> SendMessage(string accessToken, string userId);
}
