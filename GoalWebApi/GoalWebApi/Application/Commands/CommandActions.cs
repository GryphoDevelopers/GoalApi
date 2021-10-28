using GoalWebApi.Data;
using GoalWebApi.Models.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoalWebApi.Application.Commands
{
    public abstract class CommandActions
    {
        public MainValidation Validation { get; private set; }
        protected CommandActions() { Validation = new MainValidation(); }
        public async Task<bool> SaveDatabase(IUnitOfWork bd)
        {
            try
            {
                if (!await bd.Commit())
                {
                    Validation.AddError("Erro ao persistir os dados");
                    return false;
                }
            }
            catch (DbUpdateException ex)
            {
                Validation.AddError("Erro ao salvar dados");
                return false;
            }
            catch (Exception ex)
            {
                Validation.AddError(ex.Message);
                return false;
            }
            return true;
        }
    }
}
