using Testes.domain.Notification;
using FluentAssertions;

namespace AirLineManagement.tests.Notification
{
    public class NotifierTests
    {

        private readonly Notifier _notifier = new();

        [Fact]
        public void Should_add_notification_correctly()
        {
            //Arrange
            var message1 = "Teste";
            var message2 = "Teste2";

            //Act
            _notifier.AddNotification( new NotificationWarning( message1 ) );
            _notifier.AddNotification( new NotificationWarning( message2 ) );

            //Assert
            _notifier.GetNotifications().Should().HaveCount( 2 );
            _notifier.GetNotifications().First().Message.Should().Be( message1 );
            _notifier.GetNotifications()[1].Message.Should().Be( message2 );
        }
    }
}
