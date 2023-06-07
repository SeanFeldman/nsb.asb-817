﻿using System;
using System.Threading.Tasks;
using Contracts;
using NServiceBus;

namespace Trigger;

public class KickoffHandler : IHandleMessages<Kickoff>
{
    public async Task Handle(Kickoff message, IMessageHandlerContext context)
    {
        Console.WriteLine("Processing Kickoff message...");

        for (int i = 1; i <= 500; i++)
        {
            await context.Send("processor", new ProcessInstruction { Id = i });
        }

        Console.WriteLine("Done processing Kickoff message");
    }
}