FROM node:21.4-bullseye-slim AS production

ENV NODE_ENV production

WORKDIR /app

COPY ./package*.json /app

RUN yarn

COPY . .

CMD ["yarn","start"]