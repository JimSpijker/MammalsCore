using DAL.Context;
using DAL.Repositories;
using Logic;
using Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace MammalsUnitTests
{
    [TestClass]
    public class ReviewUnitTests
    {
        IReviewLogic reviewLogic;
        public ReviewUnitTests()
        {
            reviewLogic = new ReviewLogic(new ReviewRepository(new ReviewContext()));
        }

    }
}
