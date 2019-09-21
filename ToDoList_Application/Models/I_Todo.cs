using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList_Application.Models
{
    public interface I_Todo
    {
       
        List<V_Todo> GetList();

        int SaveData(V_Todo data);

        V_Todo GetData(int id);
        int UpdateData(V_Todo data);

        int DeleteData(int id);

        string TimeAlert();
        
    }
}
