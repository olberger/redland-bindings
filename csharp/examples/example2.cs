//
// example2.cs: C# port of Redland's redland's redland/example/example2.c
//

using Rdf;
using System;

public class Example2 {

	static string rdfxml_content =
	"<?xml version=\"1.0\"?><rdf:RDF xmlns:rdf=\"http://www.w3.org/1999/02/22-rdf-syntax-ns#\" xmlns:dc=\"http://purl.org/dc/elements/1.1/\"> <rdf:Description rdf:about=\"http://purl.org/net/dajobe/\"><dc:title>Dave Beckett's Home Page</dc:title><dc:creator>Dave Beckett</dc:creator><dc:description>The generic home page of Dave Beckett.</dc:description></rdf:Description></rdf:RDF>";
	
	public static void Main ()
	{
		Rdf.Uri uri = new Rdf.Uri ("http://example.librdf.org/");

		Storage storage = new Storage ("memory", "test", null);
		Model model = new Model (storage);

		Parser parser = new Parser ("raptor");
		parser.ParseStringIntoModel (rdfxml_content, uri, model);

		Statement stm = new Statement ();

		Node subject = new Node ("http://example.org/subject");
		stm.Subject = subject;

		Node predicate = new Node ("http://example.org/pred1");
		stm.Predicate = predicate;

		Node obj = new Node ("object", null, 0);
		stm.Object = obj;

		model.AddStatement (stm);

		IntPtr stdout = Util.fopen ("example2.xml", "a+");

		model.Print (stdout);

		if (!model.Contains (stm))
			Console.WriteLine ("Model does not contain statement");
		else
			Console.WriteLine ("Model contains statement");

		model.Remove (stm);

		model.Print (stdout);
	}
}