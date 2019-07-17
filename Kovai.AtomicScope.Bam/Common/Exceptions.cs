using System;

namespace Kovai.AtomicScope.Bam.Common
{
	public class InvalidBusinessProcessException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidBusinessProcessException"/> class.
		/// </summary>
		public InvalidBusinessProcessException()
			: base($"Business process name is required.")
		{

		}
	}
	public class InvalidBusinessTransactionException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidBusinessTransactionException"/> class.
		/// </summary>
		public InvalidBusinessTransactionException()
			: base("Business transaction is required.")
		{

		}
	}
	public class InvalidStageNameException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidStageNameException"/> class.
		/// </summary>
		public InvalidStageNameException()
			: base("Stage name is required.")
		{

		}
	}
	public class InvalidMainActivityId : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidMainActivityId"/> class.
		/// </summary>
		public InvalidMainActivityId()
			: base("MainActivityId is required.")
		{

		}
	}
	public class InvalidStageActivityId : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidStageActivityId"/> class.
		/// </summary>
		public InvalidStageActivityId()
			: base("StageActivityId is required.")
		{

		}
	}
	public class InvalidPreviousStage : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidPreviousStage"/> class.
		/// </summary>
		public InvalidPreviousStage()
			: base("Previous stage name is required.")
		{

		}
	}
	public class InvalidExceptionMessageCode : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidExceptionMessageCode"/> class.
		/// </summary>
		public InvalidExceptionMessageCode()
			: base("Exception message code is required.")
		{

		}
	}

	public class InvalidExceptionMessage : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidExceptionMessage"/> class.
		/// </summary>
		public InvalidExceptionMessage()
			: base("Exception message is required.")
		{

		}
	}

	public class InvalidMessageBody : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidMessageBody"/> class.
		/// </summary>
		public InvalidMessageBody()
			: base("Message body is required.")
		{

		}
	}

	public class InvalidMessageHeader : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="InvalidMessageHeader"/> class.
		/// </summary>
		public InvalidMessageHeader()
			: base("Message header is required.")
		{

		}
	}
}
