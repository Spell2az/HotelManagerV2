using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Summary description for Validation
/// </summary>
public class Validation
{
    
    public string Err { get; set; } = "";

    public Validation()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public Validation(int min, int max, string value, string type)
    {

        ValidateLength(min, max, value);
        if (IsValid())
        {
            ValidateCharacters(type, value);
        }
    }

    private void ValidateLength(int min, int max, string value)
    {
        if (value.Length == 0)
        {
            Err = "* Must not be blank.";
        }
        else if (value.Length > max)
        {
            Err = $"* Must be no more than {max} characters";
        }
        else if (value.Length < min)
        {
            Err = $"* Must be at least {min} characters";
        }
        
    }

    private void ValidateCharacters(string type, string value)

    {
        RegexOptions options = RegexOptions.IgnoreCase;//| RegexOptions.Singleline;
        var regexName = new Regex(@"[^-. 'A-Z]", options);
        var regexPostCode = new Regex(@"[^ 0-9A-Z]", RegexOptions.IgnoreCase);
        var regexNumber = new Regex(@"[^+ 0-9]");

        //Regex.IsMatch(ItemName, @"^[A-Z0-9_-]+$", RegexOptions.IgnoreCase);
        //[-'A-Z] name
        if (type == "name" && regexName.IsMatch(value))
        {
            Err = "* Only letters and ' - . characters are allowed.";
        }
        else if (type == "postcode" & regexPostCode.IsMatch(value))
        {
            Err = "* Must contain only alphanumeric characers.";
        }

        else if (type == "number" & regexNumber.IsMatch(value))
        {
            Err = "* Only numbers and + are allowed";
        }
        else if (type == "email")
        {
            CheckEmail(value);
        }
        else if (type == "date")
        {
            CheckDate(value);
        }
        else
        {
            
            Console.WriteLine(type +" "+ value);
        }
        //[0-9A-Z] postcode
        //[0-9] number
        //email
    }

    public bool IsValid()
    {

        return Err.Length == 0;
    }

    public bool CheckEmail(string email)
    {
        try
        {
            var emailAddress = new MailAddress(email);
            

        }
        catch (Exception e)
        {
            Err = "* Email is not valid.";
            return false;

        }

        return true;
    }

    public bool CheckDate(string date)
    {
        DateTime dateValue;
        if (DateTime.TryParse(date, out dateValue))
        {
            return true;
        }

        Err = "* Enter valid date in format DD/MM/YYYY.";
        return false;
    }
}