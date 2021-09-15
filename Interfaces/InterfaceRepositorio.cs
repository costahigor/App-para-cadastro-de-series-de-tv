using System.Collections.Generic;

namespace Cadastro.Series.Interfaces
{
    public interface InterfaceRepositorio<T>
    {
         System.Collections.Generic.List<T> Lista();
         T RetornaPorId(int id);
         void Inserir(T entidade);
         void Excluir(int id);
         void Atualizar(int id, T entidade);
         int ProximoId();
    }
}