using VeritabaniKatmani.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace VeritabaniKatmani.Interface
{
    public interface IDbModel
    {
        AbstractDapperRepository Repository { get; set; }
        void SetId(object id);
        void SetRepository(AbstractDapperRepository abstactRepository);




    }
}
