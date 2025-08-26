FROM node:current-alpine AS build
WORKDIR /app

COPY Greenlink.HeroicCharacter.Angular/package*.json ./
RUN npm ci --omit=dev

COPY Greenlink.HeroicCharacter.Angular/ .
RUN npm run build -- --configuration production

FROM nginx:stable-alpine AS final
WORKDIR /usr/share/nginx/html
RUN rm -rf ./*

COPY --from=build /app/dist/Greenlink.HeroicCharacter.Angular/browser .
COPY Greenlink.HeroicCharacter.Angular/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
