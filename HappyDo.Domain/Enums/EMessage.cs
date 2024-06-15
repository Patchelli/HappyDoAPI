using System;
using System.ComponentModel;

namespace HappyDo.Business.Enums
{
    public enum EMessage : ushort
    {
        [Description("{0} obrigatório.")]
        Required,

        [Description("Campo {0} permite {1} caracteres.")]
        MoreExpected,

        [Description("{0} não encontrado.")]
        NotFound,

        [Description("Não há registro de dados no sistema.")]
        EmptyList,

        [Description("Por favor selecione uma opção {0}.")]
        SelectAnOption,

        [Description("O limite máximo permitido é {0}.")]
        LimitedValue,

        [Description("{0} já possui um registro no sistema.")]
        Exist,

        [Description("{0} valor deve estar entre {1}.")]
        ValueExpected,

        [Description("{0} deve ser maior que {1}.")]
        GreatThanValue,

        [Description("{0} no formato inválido.")]
        InvalidFormat,

        [Description("{0} com valor lógico inválido.")]
        InvalidValue,

        [Description("Cenário não configurado.")]
        ErrorNotConfigured,

        // New descriptions
        [Description("{0} deve ser menor ou igual a {1}.")]
        LessOrEqual,

        [Description("{0} deve ser maior ou igual a {1}.")]
        GreaterOrEqual,

        [Description("{0} não pode ser vazio.")]
        NotEmpty,

        [Description("{0} deve ser um número positivo.")]
        PositiveNumber,

        [Description("{0} deve ser um número negativo.")]
        NegativeNumber,

        [Description("{0} não pode conter caracteres especiais.")]
        NoSpecialCharacters,

        [Description("{0} não pode conter números.")]
        NoNumbers,

        [Description("{0} não pode conter letras.")]
        NoLetters,

        [Description("{0} não pode exceder {1} caracteres.")]
        MaxLength,

        [Description("{0} deve ter pelo menos {1} caracteres.")]
        MinLength,

        [Description("{0} já está em uso.")]
        AlreadyInUse,

        [Description("{0} não pode ser zero.")]
        NotZero,

        [Description("{0} inválido.")]
        Invalid
    }
}
