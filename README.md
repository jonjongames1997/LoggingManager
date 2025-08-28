# LoggingManager Plugin Debugging Script

## About the Script

This script provides a simple and consistent way for Callout/Plugin developers to log important information to a log file for debugging purposes. By integrating this logging manager into your scripts, you can easily trace execution, diagnose issues, and record detailed information about your plugin's behavior.

## Features

- **Easy Integration:** Add a single line to your existing code to start logging.
- **Consistent Output:** Ensures all your plugin logs follow a clear format for easier identification.
- **Works with Existing Logging:** Designed to supplement your use of `Game.LogTrivial` or similar logging methods.
- **Customizable Messages:** Prepend your plugin name to every log entry for quick identification.

## How to Use

### Import the script
Import the script int your project

### Step 1: Locate Existing Logging Statements

Find any occurrence of `Game.LogTrivial` within your plugin or callout script. For example:

```csharp
Game.LogTrivial("Some important information about your plugin's process.");
```

### Step 2: Add LoggingManager Statement

Immediately after your `Game.LogTrivial` code, add the following line:

```csharp
LoggingManager.Log("YOUR PLUGIN NAME [LOG]:");
```

**Replace** `YOUR PLUGIN NAME` with the actual name of your plugin or callout for clarity.

**Example:**

```csharp
Game.LogTrivial("Starting plugin initialization...");
LoggingManager.Log("MyAwesomePlugin [LOG]: Starting initialization");
```

### Step 3: Save Your Script

After adding the `LoggingManager.Log` statement, save your script file.

---

**That's it!**  
Your plugin will now generate additional log entries, making it easier to debug and trace its activity.

## Example Usage

```csharp
public void Initialize()
{
    Game.LogTrivial("Initializing plugin...");
    LoggingManager.Log("TrafficControl [LOG]: Initialization started");

    // Plugin logic here
}
```

## Tips

- Use descriptive log messages to make debugging easier.
- Always prepend your plugin name in the log for clear separation in shared log files.
- You can add multiple `LoggingManager.Log` statements throughout your codebase to track different events.

## Troubleshooting

- If logs do not appear, ensure `LoggingManager` is properly referenced and initialized in your project.
- Check file permissions for the log directory to ensure the log file can be written.

## Contribution

Feel free to submit improvements, bug fixes, or feature requests via pull requests.

## License

Distributed under the MIT License. See `LICENSE` for more information.
