using Skyline.DataMiner.Analytics.GenericInterface;
using System;

[GQIMetaData(Name = "Rename Column")]
public class MyCustomOperator : IGQIColumnOperator, IGQIInputArguments
{
    private GQIColumnDropdownArgument _ColumnArg = new GQIColumnDropdownArgument("Column") { IsRequired = true};    
    private GQIStringArgument _nameArg = new GQIStringArgument("New name") { IsRequired = true };
    
    private GQIColumn _Column;
  	String _NewName;

    public GQIArgument[] GetInputArguments()
    {
        return new GQIArgument[] { _ColumnArg, _nameArg };
    }

    public OnArgumentsProcessedOutputArgs OnArgumentsProcessed(OnArgumentsProcessedInputArgs args)
    {
        _Column = args.GetArgumentValue(_ColumnArg);
  		_NewName = args.GetArgumentValue(_nameArg );
		
        return new OnArgumentsProcessedOutputArgs();
    }

    public void HandleColumns(GQIEditableHeader header)
    {
        header.RenameColumn(_Column, _NewName);
    }
}