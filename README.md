# QR Code App

## Overview

The **QR Code App** is a cross-platform application built with **.NET MAUI** and **Blazor**. It allows users to generate, save, and manage QR codes based on user-defined inputs. The app supports saving generated QR codes as image files to the user's device and manages a collection of named QR codes for easy reuse. The application runs on **Android**, **iOS**, and **Windows** devices.

## Features

- Generate QR codes from user-provided text.
- Preview QR codes directly in the app.
- Save generated QR codes to the device's storage.
- Store and manage named QR codes.
- Supports multiple platforms: **Android**, **iOS**, and **Windows**.
- Multilingual support with **localization** for different languages.

## Technologies Used

- **.NET MAUI**: Cross-platform framework for building native apps.
- **Blazor**: Web framework for building interactive UI components.
- **EF Core**: ORM for database interactions.
- **QRCoder**: Library for generating QR codes.
- **Dependency Injection**: For injecting services like `QrCodeService` and `IFileSaver`.

## Prerequisites

- **.NET 7 SDK** or later
- **Visual Studio 2022** with the **.NET MAUI** workload installed.
- A **device** or **emulator** for testing (iOS, Android, or Windows).
- **SQLite** database library (if storing QR codes locally).

## Setup

1. **Clone the repository**:

   ```bash
   git clone https://github.com/your-repo/QRCodeApp.git
   cd QRCodeApp
   ```
2. **Install dependencies:**
- Make sure you have the required **.NET MAUI** and **Blazor** workloads installed.
- Restore the required NuGet packages:
  ```bash
  dotnet restore
  ```
3. **Configure Database:**
- The app uses **SQLite** for storing named QR codes. Ensure your connection string is set up in `MauiProgram.cs`.
4. **Run the app:**
  ```bash
  dotnet build
  dotnet run
  ```
  Alternatively, you can run the app directly from Visual Studio by selecting the target platform (Android, iOS, or Windows) and pressing F5.
## Usage

1. **Generate a QR Code**:
   - Enter text in the input field.
   - Click the **Generate QR Code** button to see a preview of the generated QR code.

2. **Save a QR Code**:
   - Click the **Save QR Code** button to open a modal where you can name the QR code.
   - After naming, the QR code is saved to the local database and can be accessed later.

3. **View and Manage Saved QR Codes**:
   - Scroll down to see the list of saved QR codes.
   - Use the **Regenerate** button to display a QR code preview again.
   - Use the **Delete** button to remove a saved QR code.

4. **Save QR Code to Device**:
   - On supported platforms (Android, iOS, Windows), click **Download** to save the QR code as an image to your device's storage.

## Platform-Specific Notes

- **Android**: The app uses the `IFileSaver` service to save images to the device's **Downloads** folder.
- **iOS**: Ensure proper permissions are set for file access.
- **Windows**: Uses the **FileSavePicker** to choose a location for saving QR code images.

## Troubleshooting

- **Build Errors**:
  - Make sure you are using the latest version of **.NET SDK** and **Visual Studio** with **MAUI** support.
  - If encountering errors with platform-specific code, ensure you have added the appropriate `#if` directives for platform-specific implementations.

- **Database Issues**:
  - Verify that the **SQLite** database is properly configured in the `MauiProgram.cs`.
  - Ensure that database migrations are applied correctly if using **EF Core** migrations.

## Contributing

1. **Fork the repository**.
2. **Create a new branch** for your feature:

   ```bash
   git checkout -b feature-name
   ```
3. **Commit your changes**:
   ```bash
   git commit -m "Add a new feature"
   ```
4. **Push the branch**:
   ```bash
   git push origin feature-name
   ```
5. **Open a pull request.**

## License

This project is licensed under the **MIT License**. See the [LICENSE.md](LICENSE.md) file for more information.

## Acknowledgements

- [QRCoder Library](https://github.com/codebude/QRCoder): For generating QR codes.
- **Microsoft**: For providing **.NET MAUI** and **Blazor**.
- **Community Contributors**: For their suggestions and improvements.

## Contact

For any questions or suggestions, feel free to open an issue or even open a discussion.
