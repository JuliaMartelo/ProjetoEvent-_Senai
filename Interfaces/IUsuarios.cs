﻿using Projeto_Event_.Domains;

namespace Projeto_Event_.Interfaces
{
    public interface IUsuarios
    {
        void Casdastrar(Usuarios usuarios);
        Usuarios BuscarPorId(Guid Id);
        Usuarios BuscarPorEmailSenha(string email, string senha);
    }
}
