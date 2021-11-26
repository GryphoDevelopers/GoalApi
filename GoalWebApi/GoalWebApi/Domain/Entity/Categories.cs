using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalWebApi.Domain.Entity
{
    public class Categories : Entity
    {   
        public enum FID
        {
            Acessorios,
            Camera,
            Eletronicos,
            Games,
            Informatica,
            Tablets,
            Telefonia,
            Alimentos,
            Casa,
            Ferramentas,
            Pet,
            Higiene,
            Educacao,
            Esporte,
            Lazer,
            Infantil,
            Roupas
        }
        public string Name { get; set; }
        public FID Fid { get; set; }
    }
}
