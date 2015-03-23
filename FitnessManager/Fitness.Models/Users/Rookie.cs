namespace Fitness.Models.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Fitness.Models.Interfaces;

    /// <summary>
    /// фитнес режим за начинаещи
    /// </summary>
    class Rookie : User, IRookieSchedule
    {
    }
}
