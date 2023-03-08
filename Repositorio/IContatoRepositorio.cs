﻿using ControladorContatos.Models;

namespace ControladorContatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarPorId (int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adcionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);
        bool Apagar(int id);

     
    }
}
