using FluentAssertions;
using NUnit.Framework;
using TranslationManagement.Domain.TranslationJobs;

namespace TranslationManagement.Domain.Tests;

public class TranslationJobStateMachineTests
{
    [Test]
    public void Test_Valid_Transition()
    {
        var translationJobStateMachine = new TranslationJobStateMachine();

        var result = translationJobStateMachine.IsValidTransition(TranslationJobStatus.NEW, TranslationJobStatus.IN_PROGRESS);

        result.Should().BeTrue();
    }
}