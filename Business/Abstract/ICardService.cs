using Core.Utilities.Results;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICardService
    {
        IDataResult<List<Card>> GetByCardNumber(string cardNumber);
        IDataResult<List<Card>> GetAll();
        IDataResult<Card> GetById(int carId);
        IResult IsCardExist(Card card);
        IResult Add(Card card);
        IResult Update(Card card);
        IResult Delete(Card card);
    }
}
