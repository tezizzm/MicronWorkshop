# Exercise #1

## Goal

Set up the lab environment.

## Expected Results

Laptop configured with Cloud Foundry CLI, Visual Studio Code, .NET Core SDK. PWS account created and Spring Cloud Services instance deployed.

## Introduction

In this exercise, we'll set up our workstation and cloud environment so that we're ready to build and run modern .NET applications. Your instructor will provide the url and credentials for the Pivotal Cloud Foundry (PCF) instance you will be using.

Alternatively, you can sign up for a trial account of the hosted version of PCF, called Pivotal Web Services:

1. Go to <http://run.pivotal.io> and choose "sign up for free."

2. Click "create account" link on sign up page.

3. Fill in details.

4. Go to email account provided and click on veriﬁcation email link.

5. Click on "claim free trial" link and provide phone number.

6. Validate your account and create your organization.

## Package manager

We suggest using a package manager to install bootcamp software.  Alternatively use the lastest release for your given operating system found at: <https://github.com/cloudfoundry/cli/releases>

- MacOS: Homebrew\
 ( brew search PACKAGE to search)

- Windows: Chocolatey\
 ( choco search PACKAGE to search)

- Debian-Based Linux: Apt\
 ( apt search PACKAGE to search)

- Fedora-Based Linux: Yum\
 ( yum search PACKAGE to search)

## Install Cloud Foundry CLI

You can interact with Cloud Foundry via Dashboard, REST API, or command line interface (CLI). Here, we install the CLI and ensure it's conﬁgured correctly.

- Windows:

    ```Windows
    choco install cloudfoundry-cli
    ```

- MacOS:

    ```command
    brew install cloudfoundry/tap/cf-cli
    ```

- Debian and Ubuntu:

    ```Linux
    wget -q -O https://packages.cloudfoundry.org/debian/cli.cloudfoundry.org.key
    sudo apt-key add echo "deb https://packages.cloudfoundry.org/debian stable main"
    sudo tee /etc/apt/sources.list.d sudo apt-get update sudo apt-get install cf-cli
    ```

- RHEL, CentOS, and Fedora:

    ```Linux
    sudo wget -O /etc/yum.repos.d/cloudfoundry-cli.repo https://packages.cloudfoundry.org/fedora/cloud`
    sudo yum install cf-cli
    ```

Conﬁrm that it installed successfully by going to a command line, and typing:

```Windows
    cf -v
```

## Install .NET Core and Visual Studio Code

.NET Core represents a modern way to build .NET apps, and here we make sure we have everything needed to build ASP.NET Core apps.

1. Visit <https://www.microsoft.com/net/download> to download and install the latest version of the .NET Core Runtime and SDK.

    ***.NET Core Version 2.1.x is required for this workshop***

2. Conﬁrm that it installed correctly by opening a command line and typing:

    ```Windows
    dotnet --version
    ```

3. Install Visual Studio Code using your favorite package manager.

4. Open Visual Studio Code and go to `View → Extensions`

5. Search for C# and choose the top C# for Visual Studio Code option and click `Install`. This gives you type-ahead support for C#.

6. In the Terminal, type in `cf login -a <PCF API url>` and provide your credentials. Now you are connected to Pivotal Cloud Foundry.  Note the `-a` flag corresponds to the api endpoint of your instance of Pivotal Cloud Foundry.