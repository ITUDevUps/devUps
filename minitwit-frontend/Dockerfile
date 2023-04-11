# Use an official node image as the base image
FROM node:19-alpine

# Set the working directory in the container
WORKDIR /app

ENV PATH /app/node_modules/.bin:$PATH
ENV NODE_ENV production

# Copy package.json and package-lock.json to the container
COPY package*.json ./

# Install dependencies
RUN npm install --silent


# Copy the rest of the application code to the container
COPY . ./

#RUN apk add --update py3-pip
#RUN pip install --no-cache-dir -r requirements.txt

RUN npm run build

EXPOSE 3000

# Specify the command to run when the container starts
CMD [ "npx", "serve", "build" ]
