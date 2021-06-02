using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
public static class IEnumerableExtensions
{
    /*
        Traductor de IEnumerable
     */
    public static DataTable CopyAnonymusToDataTable<T>(this IEnumerable<T> info)
    {
        /*
         Funcion que devuelve un DataTable.
            <T>: Recibe cualquier clase, lo cual lo combierbe en tipo.
            info: dato iEnumerable, informacion que treae la tabla.
         */
        //Evaluacion de si el objeto es un DataRow
        var type = typeof(T);
        if (type.Equals(typeof(DataRow)))
            return (info as IEnumerable<DataRow>).CopyToDataTable();
        DataTable dt = new DataTable();
        DataRow r;
        //a es el dataRow
        //Crea la estructura del data table con cada columna o campo de la clase
        type.GetProperties().ToList().ForEach(a => dt.Columns.Add(a.Name));

        foreach (var c in info)
        {
            //Se crea una nueva fila.
            r = dt.NewRow();
            /*
                Se toma el tipo de dato y se le pasa el valor de info 
            */
            c.GetType().GetProperties().ToList().ForEach(a => r[a.Name] = a.GetValue(c, null));
            //Confirmacion de la fila despues de obtener los datos.
            dt.Rows.Add(r);
        }
        //Cuando se completa el recorrido de la tabla se devuelve.
        return dt;
    }

}