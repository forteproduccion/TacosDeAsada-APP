using System.Text.RegularExpressions;

public static class ValidationHelpers
{
    public static bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
    public static bool ValidateRFCWithHomo(string RFC)
    {
        var regEx = new Regex(@"^(([ÑA-Z|ña-z|&]{3}|[A-Z|a-z]{4})\d{2}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)(\w{2})([A|a|0-9]{1}))$|^(([ÑA-Z|ña-z|&]{3}|[A-Z|a-z]{4})([02468][048]|[13579][26])0229)(\w{2})([A|a|0-9]{1})$");
        Match result = regEx.Match(RFC);
        return result.Success;
    }
    public static bool ValidateNSS(string NSS)
    {
        var regEx = new Regex(@"^\d{11}(?:\d{2})?$");
        Match result = regEx.Match(NSS);
        return result.Success;
    }
    public static bool IsValidEmailRegEx(string email)
    {
        var regEx = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
        Match result = regEx.Match(email);
        return result.Success;
    }
    public static bool IsValidPhone(string phone)
    {
        var regEx = new Regex(@"^\d{10}(?:\d{8})?$");
        Match result = regEx.Match(phone);
        return result.Success;
    }
    public static bool IsPasswordValid(string password)
    {
        var regEx = new Regex(@"^(?=.*[\d])(?=.*[A-Z])(?=.*[a-z])(?=.*[!" + "\"" + @"#$%&\'()*+,-.\/:;<=>?@[\]^_`{|}~])[\w\d!" + "\"" + @"#$%&\'()*+,-.\/:;<=>?@[\]^_`{|}~]{5,20}$");
        Match result = regEx.Match(password);
        return result.Success;
    }
}
