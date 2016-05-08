using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Document
{
    public int Id { get; set; }
    public int TemplateID { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public int IsDeleted { get; set; }
    public string Date { get; set; }
    public string SignedDocument { get; set; }

    internal void Add(Document objTemplate)
    {
        throw new NotImplementedException();
    }
}