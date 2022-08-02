using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public interface IStrategy
    {
        int[] Algorithm(int[] mas, bool flag = true);
    }

}
// int[] mas – целочисленный массив, представляющий собой исходный
//набор данных для сортировки;
// flag – необязательная логическая переменная-индикатор для
//переключения режимов работы.