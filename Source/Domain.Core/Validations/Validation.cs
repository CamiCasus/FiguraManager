using System;
using System.Collections.Generic;
using Domain.Core.Interfaces.Validations;

namespace Domain.Core.Validations
{
    public class Validation<TEntity> : IValidation<TEntity>
    {
        #region Variables

        private readonly Dictionary<AccionValidar, Dictionary<string, IValidationRule<TEntity>>> _validationsRules;

        #endregion

        #region Constructor

        public Validation()
        {
            _validationsRules = new Dictionary<AccionValidar, Dictionary<string, IValidationRule<TEntity>>>
            {
                { AccionValidar.Create, new Dictionary<string, IValidationRule<TEntity>>()},
                { AccionValidar.Update, new Dictionary<string, IValidationRule<TEntity>>()},
                { AccionValidar.Delete, new Dictionary<string, IValidationRule<TEntity>>()}
            };
        }

        #endregion

        #region Metodos

        protected virtual void AddRule(IValidationRule<TEntity> validationRule, AccionValidar accionValidar)
        {
            var ruleName = validationRule.GetType() + Guid.NewGuid().ToString("D");

            if ((accionValidar & AccionValidar.Create) == AccionValidar.Create)
                _validationsRules[AccionValidar.Create].Add(ruleName, validationRule);

            if ((accionValidar & AccionValidar.Update) == AccionValidar.Update)
                _validationsRules[AccionValidar.Update].Add(ruleName, validationRule);

            if ((accionValidar & AccionValidar.Delete) == AccionValidar.Delete)
                _validationsRules[AccionValidar.Delete].Add(ruleName, validationRule);
        }

        protected virtual void RemoveRule(string ruleName, AccionValidar accionValidar)
        {
            _validationsRules[accionValidar].Remove(ruleName);
        }

        public ValidationResult Valid(TEntity entity, AccionValidar accionValidar) 
        {
            var result = new ValidationResult();
            var validationRulesPerAction = _validationsRules[accionValidar];

            foreach (var key in validationRulesPerAction.Keys)
            {
                var rule = validationRulesPerAction[key];
                if (!rule.Valid(entity))
                    result.Add(new ValidationError(rule.ErrorMessage));
            }
            return result;
        }

        #endregion
    }
}