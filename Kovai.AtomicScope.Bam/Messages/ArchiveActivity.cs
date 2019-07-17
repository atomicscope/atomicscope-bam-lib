using System;
using Kovai.AtomicScope.Bam.Common;

namespace Kovai.AtomicScope.Bam.Messages
{
	public class ArchiveActivityRequest
	{
		/// <summary>
		/// Gets or sets the business process.
		/// </summary>
		/// <value>
		/// The business process.
		/// </value>
		
		public string BusinessProcess { get; set; }
		/// <summary>
		/// Gets or sets the business transaction.
		/// </summary>
		/// <value>
		/// The business transaction.
		/// </value>
		
		public string BusinessTransaction { get; set; }
		/// <summary>
		/// Gets or sets the current stage.
		/// </summary>
		/// <value>
		/// The current stage.
		/// </value>
		
		public string CurrentStage { get; set; }
		/// <summary>
		/// Gets or sets the stage activity identifier.
		/// </summary>
		/// <value>
		/// The stage activity identifier.
		/// </value>
		
		public Guid StageActivityId { get; set; }
		/// <summary>
		/// Gets or sets the message body.
		/// </summary>
		/// <value>
		/// The message body.
		/// </value>
		
		public string MessageBody { get; set; }
		/// <summary>
		/// Gets or sets the message header.
		/// </summary>
		/// <value>
		/// The message header.
		/// </value>
		
		public string MessageHeader { get; set; }
		/// <summary>
		/// Gets or sets the ResourceId.
		/// </summary>
		/// <value>
		/// The previous stage.
		/// </value>

		public string ResourceId { get; set; }


		/// <summary>
		/// Validates this instance.
		/// </summary>
		/// <exception cref="InvalidBusinessProcessException"></exception>
		/// <exception cref="InvalidBusinessTransactionException"></exception>
		/// <exception cref="InvalidStageNameException"></exception>
		/// <exception cref="InvalidStageActivityId"></exception>
		public void Validate()
		{
			if (string.IsNullOrEmpty(BusinessProcess))
				throw new InvalidBusinessProcessException();
			if (string.IsNullOrEmpty(BusinessTransaction))
				throw new InvalidBusinessTransactionException();
			if (string.IsNullOrEmpty(CurrentStage))
				throw new InvalidStageNameException();
			if (StageActivityId == default)
				throw new InvalidStageActivityId();

		}
	}
}
