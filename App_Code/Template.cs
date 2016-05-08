using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Template
{
    public int Id { get; set; }
    public int CategoryId { get; set; }
    public string Subject { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public string leftFooter { get; set; }
    public string rightFooter { get; set; }

    public string Date { get; set; }
    public int IsDeleted { get; set; }
}