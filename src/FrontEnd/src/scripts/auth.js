var Oidc = window.Oidc,
    UserManager = Oidc.UserManager;

if((Oidc && Oidc.Log && Oidc.Log.logger)){
    Oidc.Log.logger = console;
}
new UserManager().signinRedirectCallback().then(function (user) {
  localStorage.setItem('token', user.access_token);

  window.location = "/";
}).catch(function (er) {
        console.log(er);
});
