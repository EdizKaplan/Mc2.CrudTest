using FluentValidation;
using Mc2.CrudTest.Presentation.Shared;
using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Client.Controller
{

    public class CustomerValidator : AbstractValidator<CustomerViewModel>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.DateOfBirth).NotEmpty().WithMessage("Date of birth is required.")
                                         .Must(BeAValidDate).WithMessage("Invalid date of birth.");
            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Phone number is required.")
                                        .Must(BeAValidMobileNumber).WithMessage("Invalid phone number.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
                                  .EmailAddress().WithMessage("Invalid email address.");
            RuleFor(x => x.BankAccountNumber).NotEmpty().WithMessage("Bank account number is required.")
                                              .Must(BeAValidBankAccountNumber).WithMessage("Invalid bank account number.");
        }

        private bool BeAValidDate(DateTime date)
        {
            return true;
        }

        private bool BeAValidMobileNumber(string phoneNumber)
        {
            PhoneNumberUtil phoneUtil = PhoneNumberUtil.GetInstance();
            try
            {
                PhoneNumber number = phoneUtil.Parse(phoneNumber, null);
                return phoneUtil.IsValidNumberForRegion(number, "TR");
            }
            catch (NumberParseException)
            {
                return false;
            }
        }

        private bool BeAValidBankAccountNumber(string accountNumber)
        {
            return true;
        }
    }

}
