
CONTAINER_NAME=$1
DATABASE_NAME=$2

if [ -z $CONTAINER_NAME ]
then
  echo "Usage: $0 [container name] [database name]"
  exit 1
fi

if [ -z $DATABASE_NAME ]
then
  echo "Usage: $0 [container name] [database name]"
  exit 1
fi

# Set bash to exit if any further command fails
set -e
set -o pipefail

# Create a file name for the backup based on the current date and time
# Example: 2019-01-27_13:42:00.master.bak
FILE_NAME=$(date +%Y-%m-%d_%H:%M:%S.$DATABASE_NAME.bak)

# Make sure the backups folder exists on the host file system
mkdir -p "./backups"

echo "Backing up database '$DATABASE_NAME' from container '$CONTAINER_NAME'..."

# Create a database backup with sqlcmd
docker exec -it "$CONTAINER_NAME" /opt/mssql-tools/bin/sqlcmd -b -V16 -S localhost -U SA -Q "BACKUP DATABASE [$DATABASE_NAME] TO DISK = N'/var/opt/mssql/backups/$FILE_NAME' with NOFORMAT, NOINIT, NAME = '$DATABASE_NAME-full', SKIP, NOREWIND, NOUNLOAD, STATS = 10"

echo ""
echo "Exporting file from container..."

# Copy the created file out of the container to the host filesystem
docker cp $CONTAINER_NAME:/var/opt/mssql/backups/$FILE_NAME ./backups/$FILE_NAME

echo "Backed up database '$DATABASE_NAME' to ./backups/$FILE_NAME"
echo "Done!"