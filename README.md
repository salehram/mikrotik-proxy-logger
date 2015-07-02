# Mikrotik Proxy Logger
http://mikrotik-proxy-logger.is-linux.com (domain is offline for a while)

Current version: 0.0.3a - Download from "release" on top of the page

# Version 0.0.3a:
* SERVICE: Fixed the code which the service use to grab the accounting data in order to display the correct numbers.
* SERVICE: There is a bug where the service will crash if the computer goes into sleep mode then resume after.
* GUI: We can now have a full user report viewed from the menu: Reports -> Single user reports -> View single user report.
* GUI: Added chart controls to make reports more convenient, but will need more testing and work on it.

This software is aiming to fulfil all the requirements from such application, I have seen many applications like this, but each one is having a major disadvantage, such as limited in reporting functionality, or being cache based software (meaning you need to MANUALLY import the logs from the Mikrotik device EVERYDAY), or being a Linux dependent only, or also being a central application, where it can only be ran from one location everytime…

The idea of this software will try to fix all the above (and many other) issues, so we will have:

* Plenty of options in reports generation and flexibility in report conditions.
* Will capture all incoming logs and put them in the database in real-time,
* You can install this application anywhere on the network… as it will come in 2 parts, a service to capture and store the data, and a GUI to read and generate the reports.
