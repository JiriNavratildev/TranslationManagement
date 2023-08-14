using FluentAssertions;
using NUnit.Framework;
using TranslationManagerClean.Domain.TranslationJobs;

namespace TranslationManagement.Domain.Tests;

public class TranslationJobTests
{
    [Test]
    public void Test_Create_TranslationJob()
    {
        const string customerName = "John Doe";
        const string originalContent = "Sample content";
        
        var translationJob = TranslationJob.Create(customerName, originalContent);
        
        translationJob.Should().NotBeNull();
        translationJob.CustomerName.Should().Be(customerName);
        translationJob.OriginalContent.Should().Be(originalContent);
        translationJob.TranslatedContent.Should().BeNull();
    }
    
    [Test]
    public void Test_Calculate_Price()
    {
        const string customerName = "John Doe";
        const string originalContent = "Sample content";
        const decimal pricePerCharacter = 0.01m;
        
        var translationJob = TranslationJob.Create(customerName, originalContent, pricePerCharacter);
        
        translationJob.Should().NotBeNull();
        translationJob.Price.Should().Be(originalContent.Length * pricePerCharacter);
    }

    [Test]
    public void Test_Update_Status()
    {
        const string customerName = "John Doe";
        const string originalContent = "Sample content";
        var translationJob = TranslationJob.Create(customerName, originalContent);
        
        var canUpdate = translationJob.TryUpdateStatus(TranslationJobStatus.INPROGRESS);

        canUpdate.Should().BeTrue();
        translationJob.Status.Should().Be(TranslationJobStatus.INPROGRESS);
    }
    
    [Test]
    public void Test_Invalid_Update_Status()
    {
        const string customerName = "John Doe";
        const string originalContent = "Sample content";
        var translationJob = TranslationJob.Create(customerName, originalContent);

        var canUpdate = translationJob.TryUpdateStatus(TranslationJobStatus.COMPLETED);
        canUpdate.Should().BeFalse();
    }
}