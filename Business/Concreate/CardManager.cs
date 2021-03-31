using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concreate
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;
        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult Add(Card card)
        {
            _cardDal.Add(card);
            return new SuccessResult();
        }

        public IResult Delete(Card card)
        {
            _cardDal.Delete(card);
            return new SuccessResult();
        }

        public IDataResult<List<Card>> GetAll()
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll());
        }

        public IDataResult<List<Card>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<Card>>(_cardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<Card> GetById(int carId)
        {
            return new SuccessDataResult<Card>(_cardDal.Get(c => c.CardId == carId));
        }

        public IResult IsCardExist(Card card)
        {
            var result = _cardDal.Get(c => c.NameOnTheCard == card.NameOnTheCard && c.CardNumber == card.CardNumber && c.CardCvv == card.CardCvv);
            if(result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(Card card)
        {
            _cardDal.Update(card);
            return new SuccessResult();
        }
    }
}
