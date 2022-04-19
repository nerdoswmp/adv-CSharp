using System;
using System.Collections.Generic;

namespace Interfaces;
public interface IDataController<T, O>
{
    public T findById(int id);

<<<<<<< HEAD
    public List<T> getAll();
=======
    public List<T> getAll();    
>>>>>>> 37d84bb2a7f1d801a26eb71a3a420c2cc05360c9

    public void update(T obj);

    public void delete(T obj);

    public T convertModelToDTO();
}