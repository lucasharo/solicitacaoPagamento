using Entidades;
using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private IHttpContextAccessor contextAccessor;
        public Usuario usuario;
        public Usuario usuarioAplicacao;

        public UsuarioNegocio(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        private HttpClient GetHttpClient()
        {
            var client = new HttpClient();

            client.DefaultRequestHeaders.Add(HeaderNames.Authorization, "Bearer " + GetToken());

            return client;
        }

        private string GetToken()
        {
            if (contextAccessor.HttpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out var token))
            {
                token = token.ToString().Replace("Bearer ", "");

                return token.ToString();
            }

            return null;
        }

        private string GetIdLogin()
        {
            var handler = new JwtSecurityTokenHandler();

            var tokenS = handler.ReadToken(GetToken()) as JwtSecurityToken;

            var idLogin = tokenS.Claims.Where(x => x.Type == JwtRegisteredClaimNames.Sub).FirstOrDefault().Value;

            return idLogin;
        }

        public Usuario GetUsuario()
        {
            try
            {
                if (this.usuario == null)
                {
                    var client = GetHttpClient();

                    var response = client.GetAsync($"{Util.Configuration.GetSection("Aplicacoes").Value}api/Usuario/GetUsuario?idLogin={GetIdLogin()}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var dados = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result).dados;

                        this.usuario = ((JObject)dados).ToObject<Usuario>();

                        return this.usuario;
                    }
                    else
                    {
                        throw new NegocioException("Erro ao consular Usuário");
                    }
                } else
                {
                    return this.usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Usuario GetUsuarioAplicacao()
        {
            try
            {
                if (this.usuarioAplicacao == null)
                {
                    var client = GetHttpClient();

                    var response = client.GetAsync($"{Util.Configuration.GetSection("Aplicacoes").Value}api/usuario/GetUsuarioAplicacao?idLogin={GetIdLogin()}&idAplicacao=10").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var dados = JsonConvert.DeserializeObject<dynamic>(response.Content.ReadAsStringAsync().Result).dados;

                        this.usuarioAplicacao = ((JObject)dados).ToObject<Usuario>();

                        return this.usuarioAplicacao;
                    }
                    else
                    {
                        throw new NegocioException("Erro ao consular Usuário");
                    }
                }
                else
                {
                    return this.usuarioAplicacao;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidaFuncionalidade(string chave)
        {
            var usuario = GetUsuarioAplicacao();

            return usuario.funcionalidades.Where(x => x.chave == chave).Any();
        }
    }
}