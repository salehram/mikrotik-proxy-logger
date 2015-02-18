# Mikrotik Proxy Logger
http://mikrotik-proxy-logger.is-linux.com

Current version: 0.0.2a - Download from "release" on top of the page

**Version 0.0.2a:
* SERVICE: Service can now grab "Accounting" data to generate reports for bandwidth usage.
* SERVICE: Re-written the service code to be more error free as there was some major bug in the previous code.
* GUI: Repositioned some menu items to be more logical

This software is aiming to fulfil all the requirements from such application, I have seen many applications like this, but each one is having a major disadvantage, such as limited in reporting functionality, or being cache based software (meaning you need to MANUALLY import the logs from the Mikrotik device EVERYDAY), or being a Linux dependent only, or also being a central application, where it can only be ran from one location everytime…

The idea of this software will try to fix all the above (and many other) issues, so we will have:

* Plenty of options in reports generation and flexibility in report conditions.
* Will capture all incoming logs and put them in the database in real-time,
* You can install this application anywhere on the network… as it will come in 2 parts, a service to capture and store the data, and a GUI to read and generate the reports.
