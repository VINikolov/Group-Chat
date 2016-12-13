using System;

namespace ChatServer
{
    public enum MessageTypes
    {
        UpdateMessage = 0,
        ExitMessage = 1,
        InitialMessage = 2,
        UserDisconnectedNotification = 3,
        LoginMessage = 4,
        RegisterMessage = 5,
        LoginSuccessful = 6,
        LoginFailed = 7,
        RegistrationSuccessful = 8
    }
}
